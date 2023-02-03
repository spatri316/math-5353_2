#call price, put price, call delta, put delta, gamma, vega, call theta, put theta, call rho, put rho, d1, d2

import numpy as np
from scipy.stats import distributions, stats
import scipy.stats as sc

#d1
def d1(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    return (np.log(s / k) + ((r - q + 0.5 * (np.square(v))) * t)) / (v * np.power(t, 0.5))

def d2(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    return d1(s, k, r, q, v, t) - (v * np.power(t, 0.5))

def call_price(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d1_val = d1(s, k, r, q, v, t)
    cdf_d1 = sc.norm.cdf(cdf_d1_val)
    cdf_d2_val = d2(s, k, r, q, v, t)
    cdf_d2 = sc.norm.cdf(cdf_d2_val)

    return s * np.exp(-q * t) * cdf_d1 - k * np.exp(-r * t) * cdf_d2

def put_price(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d1_val = d1(s, k, r, q, v, t)
    cdf_d1 = sc.norm.cdf(-cdf_d1_val)
    cdf_d2_val = d2(s, k, r, q, v, t)
    cdf_d2 = sc.norm.cdf(-cdf_d2_val)

    return (k * np.exp(-r * t) * cdf_d2) - (s * np.exp(-q * t) * cdf_d1)

def call_delta(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d1_val = d1(s, k, r, q, v, t)
    return sc.norm.cdf(-cdf_d1_val)

def call_delta(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d1_val = d1(s, k, r, q, v, t)
    return sc.norm.cdf(-cdf_d1_val) - 1

def gamma(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d1_val = d1(s, k, r, q, v, t)
    return stats.distributions.norm.pdf(x = cdf_d1_val)/(s * v * np.power(t, 0.5))

def vega(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d1_val = d1(s, k, r, q, v, t)
    return stats.distributions.norm.pdf(x = cdf_d1_val)*(s * np.power(t, 0.5))

def call_theta(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    pdf_d1_val = d1(s, k, r, q, v, t)
    cdf_d2_val = d2(s, k, r, q, v, t)
    pdf_val = stats.distributions.norm.pdf(x = pdf_d1_val)
    cdf_val = sc.norm.cdf(cdf_d2_val)

    return (-s*pdf_val*v)/(2 * np.power(t, 0.5)) - (r*k*np.exp(-r * t)*cdf_val)

def put_theta(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    pdf_d1_val = d1(s, k, r, q, v, t)
    cdf_d2_val = d2(s, k, r, q, v, t)
    pdf_val = stats.distributions.norm.pdf(x = pdf_d1_val)
    cdf_val = sc.norm.cdf(-cdf_d2_val)

    return (-s*pdf_val*v)/(2 * np.power(t, 0.5)) + (r*k*np.exp(-r * t)*cdf_val)

def call_rho(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d2_val = d2(s, k, r, q, v, t)
    cdf_val = sc.norm.cdf(cdf_d2_val)

    return k*t*np.exp(-r * t)*cdf_val

def put_rho(s: float, k: float, r: float, q: float, v: float, t: float) -> float:
    cdf_d2_val = d2(s, k, r, q, v, t)
    cdf_val = sc.norm.cdf(-cdf_d2_val)

    return -k*t*np.exp(-r * t)*cdf_val